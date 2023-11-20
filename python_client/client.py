import requests
import random
import urllib3

urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

BASE_URL = "https://localhost:7082"  

def load_quotes(file_url):
    with open(file_url, "r") as file:
        quotes = file.readlines()

    for quote in quotes:
        text, author = map(str.strip, quote.split('~', 1))
        json = {'Text': text,
                'Author': author,
                'Tags': []}
        response = requests.post(f"{BASE_URL}/addNewQuote", json=json, verify=False)
    
        if response.status_code == 200:
            print("Quotes loaded successfully.")
        else:
            print(f"Error loading quotes: {response.text}")

    
def get_tags():
    response = requests.get(f"{BASE_URL}/tags", verify=False)
    
    if response.status_code == 200:
        tags = response.json()
        return {tag['name']: tag['id'] for tag in tags}
    else:
        print(f"Error: {response.text}")
        return {}
    
def add_new_quote(text, author, tags):
    json = {
        "Text": text,
        "Author": author,
        "Tags": tags
    }

    response = requests.post(f"{BASE_URL}/addNewQuote", json=json, verify=False)

    if response.status_code == 200:
        print("Quote added successfully.")
    else:
        print(f"Error: {response.text}")

def display_random_quote():
    response = requests.get(f"{BASE_URL}/quotes", verify=False)

    if response.status_code == 200:
        quotes = response.json()
        random_quote = random.choice(quotes)
        print(f"Random Quote is ...\nQuote: {random_quote['text']}\nAuthor: {random_quote['author']}")
    else:
        print(f"Error: {response.text}")

if __name__ == "__main__":
    tag_dict = get_tags()

    # Load quotes from txt
    # load_quotes("./quotes.txt")

    # Add new quote
    # add_new_quote("new quote.py", "Me", [tag_dict['Leadership'], tag_dict['Motivational']], )

    # Display random quote
    display_random_quote()
