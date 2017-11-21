## Restart2UEFIMONO Build 1.0.0.0
Restart2UEFI ported over to Linux via the use of systemd and the MONO framework.
Authentication is handled by polkit, if still rely on gksu, etc. Edit the desktop file 
and add your authentication method.
Dependencies gtk# >= 2.12, Mono >= 4.5, systemd 

/usr
Setup file structure for creation of packages, including .desktop, polkit policy, icons and startup scripts.
