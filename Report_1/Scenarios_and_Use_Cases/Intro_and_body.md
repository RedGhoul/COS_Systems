In order to identify system requirements and appropriate acceptance tests, it is necessary to explore scenario and use cases regarding the final product. As the COS will mainly be used in clinics and hospitals, the scenarios and use cases will be based on three main types of users:

Doctors/Oncologists: Deals directly with the patient 
Nurses: Assist doctors, constant interaction with patients
Administrators: Managers? 

Our scenario and use case scenarios will consist of 3 different levels. These levels are determined in order to prioritize system requirements. The levels are: 
- Primary
- Secondary 
- Tertiary


- Primary (Mirna)

The secondary level consists of features that enhance our products abilities and demonstrates each users authorization level. These features will aid in determining final marketing requirements of our model.  We have divided this level into two sections, security and CRUD. 

In the first section, security, authorized users can:
Log in and out of application
Access certain patients and their records

The second section, CRUD, refers to the ability to Create, Read, Upload and Destroy files. Under the secondary level:

Nurses can create a patient
Nurses can update a patient data
Nurses can read patient data
Doctors can add patient scans
Doctors can update patient scans
Doctors can read patient scans
Doctors can remove patient scans

As doctors will be our main users, they will be the most authorized users in these scenarios.  They will have the most access to the application, with the least amount of restrictions. This is since doctors and oncologists interact directly with their patients, and will be able to receive direct consent from the patient to upload certain information and are qualified to diagnose any abnormalities. Authorized nurses will be limited to creating, updating, and reading patient documents. Nurses typically spend more time with patients, which explains the need for COS access. However, nurses are not qualified to upload scans or diagnose based on image segmented results. In regards to administrators, due to privacy issues, they will be limited even further. Administrators will not have access to patient data, but will monitor these authorized users. 

- Tertiary & conclusion (Mirna)
