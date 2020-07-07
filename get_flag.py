import random
import re
import string
import traceback
import requests
import time

from bs4 import BeautifulSoup

class GetFlag():

    def execute(self, ip, port, flag_id, token, debug=False):

        # login
        payload = {
            'Username': flag_id,
            'Password': token
            }

        session = requests.Session()

        session.post('https://'+ ip +':' + str(port) + '/Account/login', data=payload, verify=False)

        
        time.sleep(2)

        r = session.get('https://'+ ip +':' + str(port) + '/Account/myPictures', verify=False)

        c = r.content

        soup = BeautifulSoup(c)
        paragraph = soup.find("p", {"class":"Description"})
        # return flag
        print(paragraph.decode_contents())
        return paragraph.decode_contents()




if __name__ == "__main__":
    gf = GetFlag()
    print(gf.execute('localhost', 5001, 'GSfgZxQoWQX67', 'zxcgnv'))
