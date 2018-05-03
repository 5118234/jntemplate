@echo off

echo ��ʼ���� JNTemplate ...
cd ../src/JinianNet.JNTemplate
if exist ..\..\tool\jiniannet.snk copy ..\..\tool\jiniannet.snk jiniannet.snk
echo ���ڻ�ԭ������
dotnet restore JinianNet.JNTemplate_core.csproj
echo ��������
if not exist ..\..\lib\netcoreapp1.1 md ..\..\lib\netcoreapp1.1
if not exist ..\..\lib\netcoreapp2.0 md ..\..\lib\netcoreapp2.0
ren .\Properties\AssemblyInfo.cs AssemblyInfo.cs.build.tmp

:cmdinput
echo ��ʼ���� ��������Ҫ���ɵİ汾�ţ���Ҫ���޸�JinianNet.JNTemplate_core.csproj �ļ��Ա���汾��һ�£�
set /p cmdtext=�����루1.1 or 2.0 or exit ����
 
if /i "%cmdtext%"=="1.1" goto BUILD11
if /i "%cmdtext%"=="2.0" goto BUILD20
if /i "%cmdtext%"=="exit" goto GOEND 
echo �������!���������룡
goto cmdinput

:BUILD11
echo ��ʼbuild1.1
dotnet build JinianNet.JNTemplate_core.csproj --configuration Release --output ..\..\lib\netcoreapp1.1 --framework netcoreapp1.1 
dotnet build JinianNet.JNTemplate_core.csproj --configuration DEBUG --output ..\..\lib\netcoreapp1.1 --framework netcoreapp1.1 
goto GOEND

:BUILD20
echo ��ʼbuild2.0
dotnet build JinianNet.JNTemplate_core.csproj --configuration Release --output ..\..\lib\netcoreapp2.10 --framework netcoreapp 2.0 
dotnet build JinianNet.JNTemplate_core.csproj --configuration DEBUG --output ..\..\lib\netcoreapp2.10 --framework netcoreapp 2.0 
goto GOEND

:GOEND
ren .\Properties\AssemblyInfo.cs.build.tmp AssemblyInfo.cs
cd ..
cd ..
cd build
echo build���...
pause