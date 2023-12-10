import requests
import random
import urllib3

# Exception Warning Off
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

# BASE URL of WEB API
BASE_URL = "https://localhost:7082/api"  
login_url = "https://localhost:7082/api/login"
register_url = "https://localhost:7082/api/register"

# Load Quote from .txt
def load_quotes(file_url, token):
    headers = {'Authorization': f'Bearer {token}'}

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
        response = requests.post(f"{BASE_URL}/addNewQuote", headers=headers , json=json, verify=False)
    
        if response.status_code == 200:
            print("Quotes loaded successfully.")
        else:
            print(f"Error loading quotes: {response.text}")

# Get Tags
def get_tags():
    headers = {'Authorization': f'Bearer {access_token}'}
    # GET Request
    response = requests.get(f"{BASE_URL}/tags",headers=headers, verify=False)
    
    if response.status_code == 200:
        tags = response.json()
        # Return Dictionary since request needs tag id instead of string
        return {tag['name']: tag['id'] for tag in tags}
    else:
        print(f"Error: {response.text}")
        return {}
    
def get_tag_name_by_number(tag_number):
    for name, number in tag_dict.items():
        if number == tag_number:
            return name
    return None

#populate tag options for the user
def choose_tag():
    print("Choose a tag:")
    print('0 - proceed \"add new quote\"')
    for i, tag in enumerate(tag_dict, start=1):
        print(f"{i}. {tag}")
    tags = []
    while True:
        try:
            choice = int(input("Enter the number corresponding to your choice: "))
            if 1 <= choice <= len(tag_dict):
                if choice not in tags :
                    tags.append(tag_dict[get_tag_name_by_number(choice)])
                    print("Tag successfuly included")
                else:
                    print("this tag is already included")
            elif choice is 0:
                return tags
            else:
                print("Invalid choice. Please enter a valid number.")
        except ValueError:
            print("Invalid input. Please enter a number.")

# Add New Quote
def add_new_quote(access_token):
    text, author, tags = prompt_quote()
    headers = {'Authorization': f'Bearer {access_token}'}

    # JSON object
    json = {
        "Text": text,
        "Author": author,
        "Tags": tags
    }

    # POST Request
    response = requests.post(f"{BASE_URL}/addNewQuote",headers=headers, json=json, verify=False)

    if response.status_code == 200:
        print("Quote added successfully.")
    else:
        print(f"Error: {response}")

# add new quote
def prompt_quote():
    # Prompt the user for quote details
    text = input("Enter the quote text: ")
    author = input("Enter the author: ")

    # Prompt the user for tags (multiple tags can be entered)

    tags = choose_tag()
    return text, author, tags

# Display Random Quote
def display_random_quote(access_token):
    headers = {'Authorization': f'Bearer {access_token}'}
    # GET Request
    response = requests.get(f"{BASE_URL}/quotes",headers=headers, verify=False)

    if response.status_code == 200:
        quotes = response.json()
        # Select random quote
        random_quote = random.choice(quotes)
        print(f"Random Quote is ...\nQuote: {random_quote['text']}\nAuthor: {random_quote['author']}")
    else:
        print(f"Error: {response}")


def handle_login(login_url):
    username = input('Username? ')
    password = input('Password? ')
    
    result = login_user(login_url, username, password)
    print(result['message'] + '\n')

    return result['token']


def login_user(login_url, username, password):
    headers = {
        'Content-Type': 'application/json'
    }

    login_request = {
      'UserName': username,
      'Password': password
    }

    resp = requests.post(login_url, headers=headers, json=login_request, verify=False)
    
    result = {}
    if resp.status_code == 200:
        result['success'] = True        
        login_result = resp.json()
        result['token'] = login_result['token']
        result['message'] = 'Logged in successfully'
    else:
        result['success'] = False
        result['token'] = ''
        result['message'] = 'There was a problem logging in'
        print(f'Detailed error message: {resp}')

    return result


def register_user(register_url, first_name, last_name, username, password, email, phone_number):
    headers = {
        'Content-Type': 'application/json'
    }

    # Note: for now we'll just hard-code the presence of the TaskManager role
    register_request = {
        'firstName': first_name,
        'lastName': last_name,
        'userName': username,
        'password': password,
        'email': email,
        'phoneNumber': phone_number,
        'roles': ['USER']
    }

    resp = requests.post(register_url, headers=headers, json=register_request, verify=False)

    result = {}
    if resp.status_code == 201:
        result['success'] = True        
        result['message'] = 'User registered successfully'
    else:
        result['success'] = False
        
        result['message'] = 'There was a problem registering this new user'
        print(f'Detailed error message: {resp.text}')

    return result


def handle_register_user(register_url):
    first_name = input('First name? ')
    last_name = input('Last name? ')
    username = input('Username? ')
    password = input('Password? ')
    email = input('Email? ')
    phone_number = input('Phone number? ')
    
    result = register_user(register_url, first_name, last_name, username, password, email, phone_number)
    print(result['message'] + '\n')

access_token = ''

# Main
if __name__ == "__main__":
    tag_dict = get_tags()
    done = False
    main_title = '\n\nWhat do you want to do? '
    main_options = ['Register a user', 'Log in', 'Load Quotes from file', 'Randomly selected quote', 'Add a new quote', 'Quit']

    while not done:
        print('\n' + '\n'.join([f'{i+1}). {main_options[i]}' for i in range(len(main_options))]))    
        main_index = int(input(main_title)) - 1
        print('')

        if main_index == 0:
            handle_register_user(register_url)
        elif main_index == 1:
            access_token = handle_login(login_url)
        elif main_index == 2:
            if access_token is not '':
                load_quotes("./quotes.txt", access_token)
            else:
                print('Message: Please login or register.')
        elif main_index == 3:
            if access_token is not '':
                display_random_quote(access_token)
            else:
                print('Message: Please login or register.')
        elif main_index == 4:
            if access_token is not '':
                add_new_quote(access_token)
            else:
                print('Message: Please login or register.')
        else:
            print('\n\nGoodbye!\n')
            done = True

    # Load quotes from txt
    # load_quotes("./quotes.txt")

    # Add new quote
    # add_new_quote("new quote.py", "Me", [tag_dict['Leadership'], tag_dict['Motivational']], )

    # Display random quote
    # display_random_quote()
