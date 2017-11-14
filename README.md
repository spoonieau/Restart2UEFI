# Restart2UEFI
Utility's to restart uefi systems to firmware. An easyer way to get your system to boot to the motherboards firmware interface than 
going Win's recovery options, to finding a pappercilp with certain notebooks.

## Restar2UEFI winforms build 1.0.0.0
Winforms build, will work on Win 8 to 10

## Restar2UEFIAPP UWP build 1.1.0.0
Restart2UEFI winforms build ported to UWP.
Needs Restart2UEFIHelper.exe in projects win32 dir.
Was going to be release on the windows store but due to needing the use of a win32exe and only holding a developer licence, 
I was unable to submit and have a compiled App available.

##Restar2UEFIHelper build 1.0.0.0
Helper exe need by Restart2UEFIAPP. The UWP app luanches and passes arg's to this helper, then the helper makes to calls to the OS.
Compile and place the Restart2UEFIHelper.exe into the win32 dir of the Restar2UEFIAPP project.
