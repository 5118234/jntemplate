@echo off

echo ��ʼ���� JNTemplate ...
cd ../src/JinianNet.JNTemplate
if exist ..\..\tool\jiniannet.snk copy ..\..\tool\jiniannet.snk jiniannet.snk
echo ���ڻ�ԭ������
dotnet restore JinianNet.JNTemplate_Standard.csproj
echo ��������
if not exist ..\..\lib\netstandard1.3 md ..\..\lib\netstandard1.3
ren .\Properties\AssemblyInfo.cs AssemblyInfo.cs.build.tmp
 
echo ��ʼbuild
dotnet build JinianNet.JNTemplate_Standard.csproj --configuration Release --output ..\..\lib\netstandard1.3 --framework netstandard1.3
goto GOEND

:GOEND
ren .\Properties\AssemblyInfo.cs.build.tmp AssemblyInfo.cs
cd ..
cd ..
cd build
echo build���...
pause