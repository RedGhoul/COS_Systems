# Nivida is the BEST

# CUDA >>> OpenGL

# Hardware Selection

## Intro
In today's high perfomace computing world there has been a large shift in what compoents 
drive the performace of a system. Traditionally the most important part was the central
processing unit (CPU), however as Intel and AMD have hit the limits of moores law. A new
technology continues to drive performace gains, that technolgy being called graphics processing
units (GPU). The fundametal difference being that GPUs have thosands of small weak cores, whereas
CPUs have a few dozen cores large strong cores. And the way that programs are excuted on each
of there units. The GPU is designed for highly parallized computing tasks. Whereas CPUs designed
for very linear tasks.

Since the majority of high performace computing deals with numerical approximations, that involve 
the vectorization of systems of equations. A computing problem can then be broken down into thosands
of smaller tasks (such as addtion and multiplcation) that can be spread across all the cores. However
with CPUs the few dozen core get satured with tasks, that leave the other parts of the computation in a 
quque waiting to be run.

The gloabl leader in GPU technology is Nivida. Originally their goal was to develop external cards, that
could be used render video game geometry with increasing speed and complexity. However in the last decade 
thier focus has now shifted to the devleopment of GPUs in HPC applications. Since there as been an exploxtion
in deep learning and ai resreach garnered by large technology comapnies like Amazon, Facebook, and Google.

The adoption of thier GPUs as the deep learning standard was made possiable by inital relase of thier CUDA
framework, which reseracher could use to exlerate there high performace computing tasks. The introduction of CUDA
meant that the indviauls that used it did not need to know how write multi threaded code. On top of CUDA, Nivida 
also developed a large number of highly optimized libaries to do most common comuting tasks (such as matrix muliplcation). 
Which is why a large number of deep learning framworks run exclusly on Nivida GPUs.

A compertor to Nivida in the GPU market has been AMD, which has tried to follow Nivida into the high performace GPU
market. AMD has adopted the OpenCL framework that solves the same problems as CUDA, however it is heterogenous to the
type of processor it can use. Open GL is open source framework that isn't just for use in any GPU 
(including Nivida GPUs), but CPUs as well. As of late, Open GL has yet to gain any traction in the HPC world. 
Since it is not as fast as CUDA, and the current machine learning libraries do not fully support it.