import mritopng
import multiprocessing

CDM_FOLDER_LOCATION = 'A:\SPIE_AAPMLungCT\SPIE-AAPMLungCTChallenge\DICOM_1'
PNG_FOLDER_LOCATION = 'A:\SPIE_AAPMLungCT'
PNG_FOLDER_NAME = '\AAPMLungCTChallengePNG2'

CDM_FOLDER_LOCATION2 = 'A:\SPIE_AAPMLungCT\SPIE-AAPMLungCTChallenge\DICOM_2'
PNG_FOLDER_LOCATION2 = 'A:\SPIE_AAPMLungCT'
PNG_FOLDER_NAME2 = '\AAPMLungCTChallengePNG3'

CDM_FOLDER_LOCATION3 = 'A:\SPIE_AAPMLungCT\SPIE-AAPMLungCTChallenge\DICOM_3'
PNG_FOLDER_LOCATION3 = 'A:\SPIE_AAPMLungCT'
PNG_FOLDER_NAME3 = '\AAPMLungCTChallengePNG4'

if __name__ == "__main__":
    jobs = []
    process = multiprocessing.Process(target=mritopng.convert_folder,args=(CDM_FOLDER_LOCATION, PNG_FOLDER_LOCATION + PNG_FOLDER_NAME, True))
    jobs.append(process)
    process = multiprocessing.Process(target=mritopng.convert_folder,args=(CDM_FOLDER_LOCATION2, PNG_FOLDER_LOCATION2 + PNG_FOLDER_NAME2, True))
    jobs.append(process)
    process = multiprocessing.Process(target=mritopng.convert_folder,args=(CDM_FOLDER_LOCATION3, PNG_FOLDER_LOCATION3 + PNG_FOLDER_NAME3, True))
    jobs.append(process)

    # Start the processes
    for j in jobs:
        j.start()

    # Ensure all of the processes have finished
    for j in jobs:
        j.join()

    print("List processing complete")

# mritopng.convert_folder(CDM_FOLDER_LOCATION, PNG_FOLDER_LOCATION + PNG_FOLDER_NAME, )

""" 
CDM_FOLDER_LOCATION = 'A:\SPIE_AAPMLungCT\SPIE-AAPMLungCTChallenge\B_2'
PNG_FOLDER_LOCATION = 'A:\SPIE_AAPMLungCT'
PNG_FOLDER_NAME = '\AAPMLungCTChallengePNG'

mritopng.convert_folder(CDM_FOLDER_LOCATION, PNG_FOLDER_LOCATION + PNG_FOLDER_NAME, auto_contrast=True) """