import random
import re
import string
import traceback
import requests
import time


POSSIBILITIES = string.ascii_uppercase + string.digits + string.ascii_lowercase
POSSIBILITIES2 = string.ascii_lowercase
def generate_str(length):

    return ''.join(random.choice(POSSIBILITIES) for x in range(length))

def generate_str2(length):
    return ''.join(random.choice(POSSIBILITIES2) for x in range(length))

class SetFlag():



    def execute(self, ip, port, flag, debug=False):

        #create token and flag_id
        token = generate_str2(length=6)
        flag_id = generate_str(13)

        #create account with flag_id as Username and token as password
        payload = {
            'Username': flag_id,
            'Email': flag_id+'@example.net',
            'Password': token,
            'ConfirmPassword' : token,
            }

        requests.post('https://'+ ip +':' + str(port) + '/Account/Register', data=payload, verify=False)

        time.sleep(2)


        #login 
        payload = {
            'Username': flag_id,
            'Password': token,
            }

        session = requests.Session()
        session.post('https://'+ ip +':' + str(port) + '/Account/login', data=payload, verify=False)


        #upload image
        multipart_form_data = {
            'picture' : ('mrsatan.jpg', open('./mrsatan.jpg', 'rb'))
        }

        session.post('https://'+ ip +':' + str(port) + '/Account/UploadImage', files=multipart_form_data)

        time.sleep(2)

        # set flag as description of uploaded image
        payload = {
            'Path' : 'mrsatan.jpg',
            'Description' : flag
        }

        session.post('https://'+ ip +':' + str(port) + '/Account/SetDescription', data=payload, verify=False)



if __name__ == "__main__":
    sf = SetFlag()
    sf.execute('localhost', 5001, 'test2')