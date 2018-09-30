import os, uuid, sys
from flask import Flask, request, redirect, url_for
from azure.storage.blob import BlockBlobService
import mritopng
app = Flask(__name__)

# this will be put in a config file at some point
account = 'cosscans'
key = '93suLFnShxYbT2AvchF4IIE5RGjs1RdWTQl5SGiETLqJPuhBIfsK6rpWkc6rQhMhw1VW/ZNNybAE5MKstgtu5Q=='
container = 'pscans'

@app.route('/')
def convertDCM2PNG():
    try:
        block_blob_service = BlockBlobService(account_name=account, account_key=key)

        local_path=os.path.expanduser("~/Documents")
        local_file_name ="usersName_1.dcm"
        full_path_to_file =os.path.join(local_path, local_file_name)

        generator = block_blob_service.list_blobs(container)
        for blob in generator:
            if blob.name == local_file_name:
                block_blob_service.get_blob_to_path(container, local_file_name, full_path_to_file)
        
        png_File_name = "usersName_1.PNG"
        png_File_Path = os.path.join(local_path, png_File_name)

        mritopng.convert_file(full_path_to_file,png_File_Path,True)

        block_blob_service.create_blob_from_path(container, png_File_name, png_File_Path)
        
    except Exception as e:
        print(e)

    return 'YOLO LYFE'

if __name__ == '__main__':
    app.run()