@echo off
ren ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs.build.tmp AssemblyInfo.cs
ren ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs.build.tmp AssemblyInfo.cs
rd ..\src\JinianNet.JNTemplate\obj\Debug /s /q
rd ..\src\JinianNet.JNTemplate\obj\Release /s /q
del ..\src\JinianNet.JNTemplate\obj\*.* /f /s /q
echo ������ɣ�������ʹ��VS2015/13/12�򿪽������ JinianNet.JNTemplate.sln ��
pause