@echo off
echo ��ʼ����JNTemplate 2.0 ...
set fdir=%WINDIR%\Microsoft.NET\Framework
cd ../src/JinianNet.JNTemplate
echo v2.0.50727
%fdir%\v3.5\csc.exe /target:library /out:../../lib/2.0/JinianNet.JNTemplate.dll /doc:../../lib/2.0/JinianNet.JNTemplate.xml /keyfile:../../tool/jiniannet.snk /warn:3 /nologo /o /recurse:*.cs
%fdir%\v4.0.30319\csc.exe /target:library /out:../../lib/4.0/JinianNet.JNTemplate.dll /doc:../../lib/4.0/JinianNet.JNTemplate.xml /keyfile:../../tool/jiniannet.snk /warn:3 /nologo /o /recurse:*.cs
cd ..
cd ..
cd build
echo �������...
pause