<h1 align="center">Car-service</h1>
<p align="center">
 Web application created with <b>React</b> and <b>.NET 7</b> to manage car service orders<br/>
</p>
<br/>

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents :page_with_curl:</h2></summary>
  <ol>
    <li>
      <a href="#about-">About 🤔 </a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started-">Getting started 🚀</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#how-does-it-work-">How does it work 📔</a></li>
    <li><a href="#visualization-camera-with-a-guide-">Visualization :camera: with a guide 📙</a></li>
    <li><a href="#contributing-heart">Contributing ❤️</a></li>
    <li><a href="#license-">License 📝</a></li>
    <li><a href="#contact-">Contact ☎</a></li>
  </ol>
</details>

<!-- ABOUT -->
## About 🤔
<p align="justify">
  Welcome to <b>Car-service</b>, a product of my dedication during my computer science studies. 
  While implementing this application I used best practices in software development that I could learn during the studies.
  It offers a user-friendly interface tailored to meet the needs of diverse users. It's not only responsive but also designed for user comfort and efficiency.</br> 
</p>


### Built With 

* [React](https://react.dev/learn/installation), [JavaScript](https://developer.mozilla.org/en-US/docs/Web/JavaScript), [CSS](https://developer.mozilla.org/en-US/docs/Web/CSS), [HTML](https://developer.mozilla.org/en-US/docs/Web/HTML)
* [.NET](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) with [C#](https://learn.microsoft.com/pl-pl/dotnet/csharp/) and [Docker](https://docs.docker.com/get-started/)

<br/>

<!-- GETTING STARTED -->
## Getting started 🚀

### Prerequisites

* [Git](https://git-scm.com/) 
  * Follow the guide
    > https://github.com/git-guides/install-git
* [Node.JS](https://nodejs.org/en/) and [Npm](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)
* [Docker](https://docs.docker.com/get-started/)


<br/>

### Installation

1. Use your command line and clone the repository:
```
 git clone https://github.com/iamxdave/car-service.git
```
2. Go to the clonned folder: 
```
cd car-service
```
3. Install packages
```
cd frontend
npm -i
```
4. Add .env folder in _car-service_ for database URL, put this line inside
```
DATABASE_URL = 'postgresql://root:root@localhost:5432/car-service'
```
5. Run docker compose file in _car-service_ folder
```
docker-compose up
```
**Important!**
_Login and password for db you can find in docker-compose_

7. Run application in terminal
```
dotnet run
npm run start
```
<br/>

<!-- HOW DOES IT WORK-->
## How does it work 📔
<p align="justify">
  The Car Service Application is designed to provide a seamless experience for users seeking automotive solutions. This platform offers a range of features tailored to enhance your car-related needs while prioritizing security and convenience.</br>
  - User authentication
  - Cookie based credentials
  - Data tracking
  - Data security
</p>
  

<br/>

<!-- VISUALIZATION AND GUIDE -->
## Visualization :camera: with a guide 📙

  _The application has home page on which website redirect the user on start._

![homepage](https://github.com/iamxdave/car-service/assets/74014874/0c252f98-3f0e-4258-9888-e962f109b9c3)

  _There is also a login and register page that looks similar, here is one of them._

![login](https://github.com/iamxdave/car-service/assets/74014874/673322a6-e51b-4357-b245-298876abf94d)

  _It also alows to track your orders._

![tracking](https://github.com/iamxdave/car-service/assets/74014874/6b8d677a-5ca5-47de-83bd-adae739fdb7d)

  _Recorded gif of repairing car order submission_
  
  _Sorry for component selection style flickering caused by gif recorder and its quality_

![order2](https://github.com/iamxdave/car-service/assets/74014874/741a479a-8530-4ee0-9a34-e70e420a7fe1)

<br/>

<!-- CONTRIBUTING -->
## Contributing :heart:

<p align="justify">
 Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are <b>greatly appreciated</b>.
</p>

<br/>

<!-- LICENSE -->
## License 📝
<p align="justify"> 
 Copyright 2022 iamxdave

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at
</p>

> http://www.apache.org/licenses/LICENSE-2.0

<p align="justify"> 
 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
</p>
<br/>

<!-- CONTACT -->
## Contact ☎

dawidwrobelx@gmail.com

Project Link: [https://github.com/iamxdave/car-service](https://github.com/iamxdave/car-service)
