# [Choice] .NET version: 7.0, 6.0, 5.0, 3.1, 6.0-bullseye, 5.0-bullseye, 3.1-bullseye, 6.0-focal, 5.0-focal, 3.1-focal
ARG VARIANT="7.0"
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:0-${VARIANT}
# [Choice] Node.js version: none, lts/*, 16, 14, 12, 10
ARG NODE_VERSION="none"
RUN if [ "${NODE_VERSION}" != "none" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi
# [Optional] Uncomment this section to install additional OS packages.
RUN apt-get update && \
    export DEBIAN_FRONTEND=noninteractive && \
    apt-get -qy full-upgrade && \
    apt-get install -qy curl && \
    apt-get -y install --no-install-recommends vim && \
    curl -sSL https://get.docker.com/ | sh

RUN wget -O dotnet.tar.gz https://download.visualstudio.microsoft.com/download/pr/1f26cd3a-af60-4140-9cab-b661cfe0a1ed/4d533d26ef5d55fa17f23c207f6d3330/dotnet-sdk-6.0.411-linux-x64.tar.gz \
    && dotnet_sha512='dc8aa1f84ad97cf25a979bfc243c200b7a8e73b930b68d5eed782743d88aad823c32c267c83d7a19d3c4f910a8fae7f12d07ea5a35a1d3a97e13a8674d29037b' \
    && echo "$dotnet_sha512 dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz

# Install the quantum project templates
RUN dotnet new install Microsoft.Quantum.ProjectTemplates::0.28.277227