@echo off

:: ���ļ����ٷ������汾ר�ã�����ʱ��Գ������ǿ�������������������з�����DLL�������֡�
:: ��ͨ�û���Ҫ�����Լ��İ汾������ֱ��ʹ��build
:: ����������Կ����ʹ�ñ��ļ���

echo ��ʼ���� JNTemplate ...

set fdir=%WINDIR%\Microsoft.NET\Framework

cd ../src/JinianNet.JNTemplate

%fdir%\v3.5\csc.exe /target:library /out:../../lib/2.0/JinianNet.JNTemplate.dll /doc:../../lib/2.0/JinianNet.JNTemplate.xml /keyfile:../../tool/jiniannet.snk /warn:3 /nologo /o /recurse:*.cs

echo jntemplate for .net v2.0 �������

%fdir%\v4.0.30319\csc.exe /target:library /out:../../lib/4.0/JinianNet.JNTemplate.dll /doc:../../lib/4.0/JinianNet.JNTemplate.xml /keyfile:../../tool/jiniannet.snk /warn:3 /nologo /o /recurse:*.cs

echo jntemplate for .net v4.0 �������

cd ..

cd ..

cd build

echo �������...

pause