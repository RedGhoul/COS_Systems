## What are the types of hardware used for deep-learning applications? 

## GPUs (Graphics Processing Units)

A graphics processing unit (GPU) is a specialized electronic circuit designed to rapidly manipulate and alter memory to accelerate the creation of images in a frame buffer intended for output to a display device.
GPUs are used in embedded systems, mobile phones, personal computers, workstations, and game consoles. Modern GPUs are very efficient at manipulating computer graphics and image processing, and their highly parallel structure makes them more efficient than general-purpose CPUs for algorithms where the processing of large blocks of data is done in parallel. 

GPU computng is all about leveraging the parallelism in the GPU architecture to perform matcheatically compute intensive operations that the CPU is not designed well to handle. CPUs are designed for task switch, not a high throughput, meaning it is designed for switching between multiple tasks while storing as it switches, which makes it a high latency and low throughput device. GPUs have many computational units and have a higher bandwidth. The neural network architecture fits well with the GPU architecture because graphics processing is heavily based around matrix computation, which is the basis of neural networks.