using System;
using Gtk;
using System.Reflection;
using System.IO;
using System.Diagnostics;


public partial class MainWindow: Gtk.Window
{
	//check to see if kernel booted in uefi mode and retrun true or faulse
	bool kernelmode = Directory.Exists("/sys/firmware/efi");

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.Title = "Restart2UEFI";

		//Kernelmode true or false 
		if (kernelmode != true) 
		{
			errorNotUEFI ();
		}
		else 
		{
			firmwareUEFI ();
		}


	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		//Work around for gnome3 shell
		Environment.Exit (0);

		a.RetVal = true;
	}

	protected void OnBtnAboutClicked (object sender, EventArgs e)
	{
		MessageDialog aboutDialog = new MessageDialog (this, DialogFlags.DestroyWithParent
			, MessageType.Info, ButtonsType.Ok, "A App using inbult system functions to shutdown or restart your UEFI system to Firmware" +
		                            Environment.NewLine + "Developed by SpoonieAU " + "https://github.com/spoonieau");

		aboutDialog.Run();
		aboutDialog.Destroy ();
	}

	protected void OnBtnShutdownClicked (object sender, EventArgs e)
	{
		try
		{
			//Shutdown to firmware
			var shutdown = new ProcessStartInfo();
			shutdown.FileName = "systemctl";
			shutdown.Arguments = "--firmware-setup poweroff";
			shutdown.UseShellExecute = false;
			shutdown.CreateNoWindow = true;

			Process.Start(shutdown);
		}
		catch (Exception ex) 
		{
			//if error occurs, display in messagedialog
			MessageDialog errorshutdown = new MessageDialog (this, DialogFlags.DestroyWithParent
				, MessageType.Info, ButtonsType.Ok, "Error has occurred" + Environment.NewLine + ex.ToString());

			errorshutdown.Run ();
			errorshutdown.Destroy ();
			Environment.Exit (0);
		}

	}

	protected void OnBtnRestartClicked (object sender, EventArgs e)
	{
		try
		{
			//Reboot to firmware
			var restart = new ProcessStartInfo();
			restart.FileName = "systemctl";
			restart.Arguments = "--firmware-setup reboot";
			restart.UseShellExecute = false;
			restart.CreateNoWindow = true;

			Process.Start(restart);
		}
		catch (Exception ex) 
		{
			//if error occurs, display in messagedialog
			MessageDialog errorshutdown = new MessageDialog (this, DialogFlags.DestroyWithParent
				, MessageType.Info, ButtonsType.Ok, "Error has occurred" + Environment.NewLine + ex.ToString());

			errorshutdown.Run ();
			errorshutdown.Destroy ();
			Environment.Exit (0);
		}
	}

	//Set txtStatus, display error and exit application
	private void errorNotUEFI()
	{
		Gdk.Color rUEFI = new Gdk.Color ();
		Gdk.Color.Parse ("red", ref rUEFI);

		txtStatus.IsEditable = false;
		txtStatus.ModifyText (StateType.Normal, rUEFI);
		txtStatus.Text = "Linux Kernel not booted up in UEFI Mode";
	

		MessageDialog notUefiDialog = new MessageDialog (this, DialogFlags.DestroyWithParent, 
				MessageType.Error, ButtonsType.Ok, "Linux kernel not in UEFI mode!!" + Environment.NewLine
			+ "/sys/firmware/efi not found!! " + "Press ok to exit application");

		notUefiDialog.Run ();
		notUefiDialog.Destroy ();
		Environment.Exit (0);
	}

	//Set txtStatus, if UEFI mode
	private void firmwareUEFI()
	{
		Gdk.Color gUEFI = new Gdk.Color ();
		Gdk.Color.Parse ("green", ref gUEFI);

		txtStatus.IsEditable = false;
		txtStatus.ModifyText (StateType.Normal, gUEFI);
		txtStatus.Text = "Linux Kernel is booted up in UEFI Mode";
	}


}
