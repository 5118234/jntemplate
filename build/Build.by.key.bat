@echo off

:: ���ļ����ٷ������汾ר�ã�����ʱ��Գ������ǿ�������������������з�����DLL�������֡�
:: ��ͨ�û���Ҫ�����Լ��İ汾������ֱ��ʹ��build
:: ����������Կ����ʹ�ñ��ļ���

echo ��ʼ���� JNTemplate ...

if not exist ..\lib\2.0 md ..\lib\2.0

if not exist ..\lib\4.0 md ..\lib\4.0

set fdir=%WINDIR%\Microsoft.NET\Framework

cd ../src/JinianNet.JNTemplate

%fdir%\v3.5\csc.exe /target:library /out:../../lib/2.0/JinianNet.JNTemplate.dll /doc:../../lib/2.0/JinianNet.JNTemplate.xml /keyfile:../../tool/jiniannet.snk /warn:3 /nologo /o /recurse:*.cs

echo jntemplate for .net v2.0 �������

%fdir%\v4.0.30319\csc.exe /target:library /out:../../lib/4.0/JinianNet.JNTemplate.dll /doc:../../lib/4.0/JinianNet.JNTemplate.xml /keyfile:../../tool/jiniannet.snk /warn:3 /nologo /o /recurse:*.cs

echo jntemplate for .net v4.0 �������

cd ..

cd ..

cd build

if exist ..\src\JinianNet.JNTemplate.Test\dll\JinianNet.JNTemplate.dll del ..\src\JinianNet.JNTemplate.Test\dll\JinianNet.JNTemplate.dll
copy ..\lib\2.0\JinianNet.JNTemplate.dll ..\src\JinianNet.JNTemplate.Test\dll\JinianNet.JNTemplate.dll

echo �������...

pause