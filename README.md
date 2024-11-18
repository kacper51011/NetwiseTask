## Getting Started
To run this project, Docker desktop is needed
Follow these steps to get the project up and running on your machine:

### 1. Clone the repository

First, clone the repository to your local machine using the following command:

```bash
git clone https://github.com/kacper51011/NetwiseTask.git
```
### 2. Navigate to the project directory

After cloning the repository, you need to navigate to the folder where the `.csproj` file is located. This is important because you will be building the Docker image from this directory.

To do this, follow these steps:

1. **Open a terminal or command prompt**:

2. **Navigate to folder where csproj**:
   Use the `cd` command to change the directory to where the `.csproj` file is located. In this case, the `.csproj` file is inside the `NetwiseTask` directory

### 3. Build the Docker image

Once you are in the correct directory, you need to build the Docker image. Follow these steps to do so:

```bash
docker build -t netwise-task .
```

### 4. Run the Docker container

After building the Docker image, the next step is to run the Docker container. Follow these steps:

1. **Run the container**:
   Use the following command to start the Docker container in detached mode (`-d`) and map a local port to the container's internal port:

   ```bash
   docker run -d -p 8080:8080 netwise-task
   ```
2. **Access swagger**
   Now you can see the accessible endpoints in http://localhost:8080/swagger/index.html

