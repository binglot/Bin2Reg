App:     Bin2Reg 
Version: 1.0
Author:  Bartosz Inglot
Date:    30/10/2011


============
Description
============
I looked all over the internet but I couldn't find anything on anti-forensics related to storing binary files in the registry so I decided to develop one by myself. 

If you find it useful or have any suggestions then feel free to drop me an email at "jhi (at) o2 (.) pl".


============
How-to
============

C:\> bin2reg.exe

Bin2Reg v1.0 - an application to store binary files in the registry

Usage: bin2reg.exe [-s, -r] [registry_key] [file_path]
 -s / -r         - the action to take, "store/restore"
 registry_key    - the registry key in HKCU
 file_path       - the path of the file

Ex: bin2reg.exe -s Software\HiddenData "C:\my files\test.jpg"

c:\> 


===========
Limitation
===========

The maximum size for any single Registry value entry is 1MB. (http://scilnet.fortlewis.edu/tech/NT-Server/registry.htm)


===========
To do
===========

If the input file exceeds the maximum size then split it and save to registry in parts.

