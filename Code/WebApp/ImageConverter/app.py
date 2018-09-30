import os, uuid, sys
from flask import Flask, request, redirect, url_for, jsonify
from azure.storage.blob import BlockBlobService
import mritopng
app = Flask(__name__)

# this will be put in a config file at some point
account = 'cosscans'
key = '93suLFnShxYbT2AvchF4IIE5RGjs1RdWTQl5SGiETLqJPuhBIfsK6rpWkc6rQhMhw1VW/ZNNybAE5MKstgtu5Q=='
container = 'pscans'

# http://127.0.0.1:5000/CF?patientName=Avaneesa&scanNum=1
class returnData:
    def __init__(self,error,msg, new_file_name):
        self.error = error
        self.msg = msg
        self.new_file_name = new_file_name

    def to_JSON(self):
        return {
            'error': self.error,
            'msg': self.msg,
            'new_file_name': self.new_file_name
        }
    
@app.route('/CF')
def convert_DCM2PNG():
    patientName = request.args.get('patientName', default = "", type = str)
    scanNumber = request.args.get('scanNum', default = "1", type = str)
    try:
        block_blob_service = BlockBlobService(account_name=account, account_key=key)

        local_path=os.path.expanduser("~/Documents")
        local_file_name = patientName + "_DCM_" + scanNumber + ".dcm"
        full_path_to_file =os.path.join(local_path, local_file_name)

        generator = block_blob_service.list_blobs(container)
        for blob in generator:
            if blob.name == local_file_name:
                block_blob_service.get_blob_to_path(container, local_file_name, full_path_to_file)
        
        png_File_name =  patientName + "_PNG_" + scanNumber + ".PNG"
        png_File_Path = os.path.join(local_path, png_File_name)
        
        mritopng.convert_file(full_path_to_file,png_File_Path,True)

        block_blob_service.create_blob_from_path(container, png_File_name, png_File_Path)

        os.remove(full_path_to_file)
        os.remove(png_File_Path)
    except Exception as e:
        return jsonify(returnData(str(e),"null","null").to_JSON())

    return jsonify(returnData("null","Conversion Finished",png_File_name).to_JSON())

if __name__ == '__main__':
    app.run()