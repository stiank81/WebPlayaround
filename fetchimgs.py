
import os;

xml = "<snapshotrequest xmlns=\"http://www.vizrt.com/snapshotrequest\">\r\n\
  <position>\r\n\
    <fposition>nnnnn</fposition>\r\n\
  </position>\r\n\
</snapshotrequest>";


def ensureEmptyFolder(folderName):
    if folderName == "" or folderName == None:
        return 
    
    if not os.path.exists(folderName):
        os.mkdir(folderName)

    os.remove(foldername + "/*")
    return 


# Note: Assumes payload.xml exists in the current folder. 
def main(): 
    
    folderName = "output"
    ensureEmptyFolder(folderName)

    for i in range(10):
        filename = folderName + "/vixzscene" + str(i) + ".png"
        payload = xml
        payload = payload.replace("nnnnn", str(i))
        file = open("customsnapshotrequest.xml", 'w')
        file.write(payload)
        file.close() 
        os.system("curl -G http://iod.vizrt.com:54000/snapshot --data-urlencode p@payload.xml --data-urlencode s@customsnapshotrequest.xml > " + filename)  


if __name__ == "__main__": 
    main()
