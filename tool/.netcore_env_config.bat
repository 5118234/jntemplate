@echo off
ren ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs AssemblyInfo.cs.build.tmp
ren ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs AssemblyInfo.cs.build.tmp
rd ..\src\JinianNet.JNTemplate\obj\Debug /s /q
rd ..\src\JinianNet.JNTemplate\obj\Release /s /q
echo ������ɣ�������ʹ��VS2017�򿪽������ JinianNet.JNTemplate_core.sln ��
pause