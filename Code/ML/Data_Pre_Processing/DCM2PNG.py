import mritopng

# Convert a single file with auto-contrast
# mritopng.convert_file('/home/user/DICOM/SCAN1', '/home/user/output.png', auto_contrast=True)

CDM_FOLDER_LOCATION = 'A:\SPIE_AAPMLungCT\SPIE-AAPMLungCTChallenge'
PNG_FOLDER_LOCATION = 'A:\SPIE_AAPMLungCT\'
PNG_FOLDER_NAME = 'AAPMLungCTChallengePNG'

mritopng.convert_folder(CDM_FOLDER_LOCATION, PNG_FOLDER_LOCATION + PNG_FOLDER_NAME, auto_contrast=True)