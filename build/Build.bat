@echo off

echo ��ʼ���� JNTemplate ...

set fdir=%WINDIR%\Microsoft.NET\Framework

cd ../src/JinianNet.JNTemplate

set /p input=�Ƿ���Ҫ֧���ֶ�ȡֵ(����Y����N,Ĭ��ΪN)�� 

if "%input%"=="Y" goto Y 

goto N

:Y

%fdir%\v3.5\csc.exe /target:library /out:../../lib/2.0/JinianNet.JNTemplate.dll /doc:../../lib/2.0/JinianNet.JNTemplate.xml /warn:3 /nologo /o /define:NEEDFIELD /recurse:*.cs

echo jntemplate for .net v2.0(֧�� field) �������

%fdir%\v4.0.30319\csc.exe /target:library /out:../../lib/4.0/JinianNet.JNTemplate.dll /doc:../../lib/4.0/JinianNet.JNTemplate.xml /warn:3 /nologo /o /define:NEEDFIELD /recurse:*.cs

echo jntemplate for .net v4.0(֧�� field) �������

goto LAST

:N

%fdir%\v3.5\csc.exe /target:library /out:../../lib/2.0/JinianNet.JNTemplate.dll /doc:../../lib/2.0/JinianNet.JNTemplate.xml /warn:3 /nologo /o /recurse:*.cs

echo jntemplate for .net v2.0 �������

%fdir%\v4.0.30319\csc.exe /target:library /out:../../lib/4.0/JinianNet.JNTemplate.dll /doc:../../lib/4.0/JinianNet.JNTemplate.xml /warn:3 /nologo /o /recurse:*.cs

echo jntemplate for .net v4.0 �������

goto LAST 



:LAST

cd ..

cd ..

cd build

echo �������...

pause
exit 
