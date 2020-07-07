import random
import re
import string
import traceback
import requests
import time

from bs4 import BeautifulSoup

class Benign():

    def checkfunction(self, ip, port, flag_id, token, flag, debug=False):

            
            check = []

            #login
            payload = {
                'Username': flag_id,
                'Password': token
                }

            session = requests.Session()

            session.post('https://'+ ip +':' + str(port) + '/Account/login', data=payload, verify=False)

            
            time.sleep(2)

            #change username 
            flag_id = flag_id + "_twice"

            payload = {
                'Username': flag_id,

                }

            session.post('https://'+ ip +':' + str(port) + '/Account/ChangeUsername', data=payload, verify=False)

            session.get('https://'+ ip +':' + str(port) + '/Account/Logout', verify=False)

            time.sleep(2)

            #login with new username - first check
            payload = {
                'Username': flag_id,
                'Password': token,
                }

            session.post('https://'+ ip +':' + str(port) + '/Account/login', data=payload, verify=False)

            time.sleep(2)

            r = session.get('https://'+ ip +':' + str(port) + '/Account/myPictures', verify=False)

            c = r.content
            soup = BeautifulSoup(c)
            paragraph = soup.find("p", {"class":"Description"})

            # retrun True if function is still available. Otherwise return False
            if flag == paragraph.decode_contents():
                check.append(True)
            else:
                 check.append(False)

        
            # check if adminpage still exists
            r = session.get('https://'+ ip +':' + str(port) + '/Admin/myPictures_Admin', verify=False)

            if r.apparent_encoding == None:
               check.append(False)
            else: check.append(True)

            ## if both functions are still available then return True
            if all(checkitem == True for checkitem in check):
                return True
            else: return False
            


if __name__ == "__main__":
    bn = Benign()
    print(bn.checkfunction('localhost', 5001, 'ExampleUser', 'mypassword', 'zufaelligeFlag'))


        
        

