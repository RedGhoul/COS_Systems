# Body

Most machine learning models that are being trained in production use. Are being run on
anyone of the big three cloud computing platforms, such as Amazon Web Services (AWS), Google Cloud Platform (GCP),
and Microsoft Azure. So much so that these cloud provides have started to create virtual machine (VM) instances,
that incorprates the latest Nivida HPC GPUs. These VMs come in two different types spot instances and dedecated instances.
Spot instances, are VMs that use shared resources among a number of different VMs. They will not always have
the computing power they are rated at. Dedicated instances are VMs, that don't have to share resource with any other VMs.
So the guarantee a reliable level of computing power. For this reason they are usually 10X the price of spot instances.
However due to the addtion of these increadbaly expensive compents and thier assocated power draw, these VMs are 
expensive to run in the long term. Costing anywhere between 70 to 200 dollars USD on per month for a spot instance 
using a single GPU. 

## Display a couple of tables here

### GPC

### Azure

### AWS

It is for this reason we decided to train the models exclusively on our personal machines. 

When training models all the different parts of the PC are involved.  The three main parts the computer are 
the CPU, GPU, and Hard drives that store the trainging data. The CPU acts like a traffic controller loading data into system memeory. 
This data gets feed into GPU memeroy through the PCI - E connections in the mother borad. And then get proceeded by the GPU. This cycle
continues until the model has been suffiently trained.

If anyone of the parts discribed above is slow or lacks capcity, it creates a bottle
neck for the through put of the system, which signifcanly slows down the training process.

## Make a flow chart explaing why we need


The main machine we used was two GPU system, and the secondary system was a 1 GPU system.

### Avaneesa's Computer

    - 2x 1080 ti's
    - 1x i7 7700k
    - 32 GB RAM
    - 1 TB SSD

### Harmen's Computer

    - 1x 1070
    - 1x i7 7700k
    - 16 GB
    - 1 TB HD