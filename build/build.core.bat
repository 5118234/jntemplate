@echo off

echo ��ʼ���� JNTemplate ...
cd ../src/JinianNet.JNTemplate
echo ���ڻ�ԭ������
dotnet restore JinianNet.JNTemplate_core.csproj
echo ��������
if not exist ..\..\lib\netcoreapp1.1 md ..\..\lib\netcoreapp1.1
if not exist ..\..\lib\netcoreapp2.0 md ..\..\lib\netcoreapp2.0
ren .\Properties\AssemblyInfo.cs AssemblyInfo.cs.build.tmp
echo ��ʼbuild
dotnet build JinianNet.JNTemplate_core.csproj --configuration Release --output ..\..\lib\netcoreapp2.0 --framework netcoreapp2.0 
ren .\Properties\AssemblyInfo.cs.build.tmp AssemblyInfo.cs
cd ..
cd ..
cd build
echo build���...
pause