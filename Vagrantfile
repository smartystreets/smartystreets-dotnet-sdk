VAGRANTFILE_API_VERSION = "2"
Vagrant.configure(VAGRANTFILE_API_VERSION) do |config|
  config.ssh.forward_agent = true
  config.vm.box = "bento/ubuntu-18.04"
  config.vm.synced_folder "~/.identity", "/home/vagrant/.identity", create: true
  config.vm.provision "shell", path: "https://s3-us-west-1.amazonaws.com/raptr-us-west-1/baseline/roles/vagrant"

  # box-specific
  config.vm.provision "shell", inline: $provision
end

$provision = <<-EOF
	curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > /etc/apt/trusted.gpg.d/microsoft.gpg
	echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-bionic-prod bionic main" > /etc/apt/sources.list.d/dotnetdev.list

	apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
	echo "deb https://download.mono-project.com/repo/ubuntu stable-xenial main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list

	apt-get update
	apt-get install -y dotnet-sdk-2.1.4 mono-devel
EOF
