# SmobilerNetCoreFramework

**★★★★★** 五星级smobiler布署Linux方案，支持Docker布署

#### 介绍
Smobiler支持linux、windows布署框架,支持.net core3.1/.net 5/.net 6，完全无渗入式（Sobiler原有项目可以不用任何修改就可运行在Linux,window平台），支持Smobiler的Docker布署;

#### 系统特点

- 在window、ubuntu、centos等系统下测试通过；
- 支持以命令参数方式启动；
- 对原有项目完全无渗入式（完全不用修改）的将系统布署在linux等操作系统平台；
- 官网支持的window功能使用本系统完全可以达到（还需要完成）；
- 支持Docker容器化布署方式；


#### 使用教程

1. 由于smobiler在.net core下没有编译器，所以原有APP项目照样编译（如果是新项目，则按smobiler的教程建立Framework APP新项目），编译结果为：xxxx.exe文件；

2. git clone https://gitee.com/opaldev/smobilernetCoreframework.git  克隆下本SmobilerNetCoreFramework项目；

3. SmobilerNetCoreFramework添加项目引用：将Framework新（原）项目添加至SmobilerNetCoreFramework项目中；

4. SmobilerNetCoreFramework项目文件中：修改Setting.config文件内容，以使项目启动时能使用指定的配置项；

5. SmobilerNetCoreFramework项目编译通过（默认为.net5）；

6. 将项目拷贝到Linux服务器，

   - 可以运行命令：

   dotnet SmobilerNetCoreFramework.dll \
   -a "/home/ubuntu/FlaneAppServer/SmobilerNetCoreFramework.Test.exe"  \
   -s "SmobilerNetCoreFramework.Test.SmobilerForm1"

   注：

   > - /home/ubuntu/FlaneAppServer/SmobilerNetCoreFramework.Test.exe为本地的smobiler App应用程序，可以换成你的应用程序名；
   >
   > - SmobilerNetCoreFramework.Test.SmobilerForm1为smobiler App应用程序的启动类名（包括命名空间的全限制类名）；

   

   - 也可以指定端口号运行，如：

   dotnet SmobilerNetCoreFramework.dll -a "/home/ubuntu/FlaneAppServer/SmobilerNetCoreFramework.Test.exe"  -s "SmobilerNetCoreFramework.Test.SmobilerForm1" -p 2325 -t 2324

   -p: http-server-port

   -t: tcp-server-port

   - 命令参数格式：

     ![image-20210704014817264](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20210704014817264.png)





#### 布署说明

#### Docker布署教程

