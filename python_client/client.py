import requests
import random
import urllib3

# Exception Warning Off
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

# BASE URL of WEB API
BASE_URL = "https://localhost:7082"  

# Load Quote from .txt
def load_quotes(file_url):
    # file reader
    with open(file_url, "r") as file:
        quotes = file.readlines()

    # POST Request for each quote in quotes
    for quote in quotes:
        # slice string for correct data
        text, author = map(str.strip, quote.split('~', 1))
        # json object
        json = {'Text': text,
                'Author': author,
                'Tags': []}
        # POST
        response = requests.post(f"{BASE_URL}/addNewQuote", json=json, verify=False)
    
        if response.status_code == 200:
            print("Quotes loaded successfully.")
        else:
            print(f"Error loading quotes: {response.text}")

# Get Tags
def get_tags():
    # GET Request
    response = requests.get(f"{BASE_URL}/tags", verify=False)
    
    if response.status_code == 200:
        tags = response.json()
        # Return Dictionary since request needs tag id instead of string
        return {tag['name']: tag['id'] for tag in tags}
    else:
        print(f"Error: {response.text}")
        return {}

# Add New Quote
def add_new_quote(text, author, tags):
    # JSON object
    json = {
        "Text": text,
        "Author": author,
        "Tags": tags
    }

    # POST Request
    response = requests.post(f"{BASE_URL}/addNewQuote", json=json, verify=False)

    if response.status_code == 200:
        print("Quote added successfully.")
    else:
        print(f"Error: {response.text}")

# Display Random Quote
def display_random_quote():
    # GET Request
    response = requests.get(f"{BASE_URL}/quotes", verify=False)

    if response.status_code == 200:
        quotes = response.json()
        # Select random quote
        random_quote = random.choice(quotes)
        print(f"Random Quote is ...\nQuote: {random_quote['text']}\nAuthor: {random_quote['author']}")
    else:
        print(f"Error: {response.text}")

# Main
if __name__ == "__main__":
    tag_dict = get_tags()

    # Load quotes from txt
    # load_quotes("./quotes.txt")

    # Add new quote
    # add_new_quote("new quote.py", "Me", [tag_dict['Leadership'], tag_dict['Motivational']], )

    # Display random quote
    display_random_quote()
