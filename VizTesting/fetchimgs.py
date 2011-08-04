
import os
import shutil

xml = "<snapshotrequest xmlns=\"http://www.vizrt.com/snapshotrequest\">\r\n\
  <position>\r\n\
    <fposition>nnnnn</fposition>\r\n\
  </position>\r\n\
</snapshotrequest>";


def ensureFolderExists(folderName):
    if folderName == "" or folderName == None:
        return 
    
    if not os.path.exists(folderName):
        os.mkdir(folderName)

    # Remove any files in the folder 
    # shutil.rmtree(folderName + "/*")
    return 


# Note: Assumes payload.xml exists in the current folder. 
def main(): 
    
    folderName = "output"
    ensureFolderExists(folderName)

    for i in range(160):
        filename = folderName + "/vizscene" + str(i) + ".png"
        payload = xml
        payload = payload.replace("nnnnn", str(i))
        file = open("customsnapshotrequest.xml", 'w')
        file.write(payload)
        file.close() 
        os.system("curl -G http://iod.vizrt.com:54000/snapshot --data-urlencode p@payload.xml --data-urlencode s@customsnapshotrequest.xml > " + filename)  


if __name__ == "__main__": 
    main()
