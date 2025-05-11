FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER root
RUN apt-get update && apt-get install -y \
    texlive \
    texlive-latex-base \
    texlive-fonts-recommended \
    texlive-latex-extra \
    texlive-xetex \
    fonts-noto \
    fonts-freefont-otf \
    fonts-freefont-ttf \
    cm-super \
    texlive-fonts-extra \
    texlive-fonts-recommended \
    texlive-fonts-extra-links \
    texlive-science \
    fontconfig \
    && apt-get clean

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HireMePls.csproj", "./"]
RUN dotnet restore "HireMePls.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "HireMePls.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HireMePls.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HireMePls.dll"]


#PROD

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#
#USER app
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["HireMePls.csproj", "./"]
#RUN dotnet restore "HireMePls.csproj"
#COPY . .
#WORKDIR "/src/"
#RUN dotnet build "HireMePls.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "HireMePls.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#USER root
#RUN apt-get update && apt-get install -y --no-install-recommends \
    #texlive-xetex \
    #texlive-fonts-recommended \
    #texlive-latex-extra \
    #texlive-lang-english \
    #&& apt-get clean \
    #&& rm -rf /var/lib/apt/lists/*
#
 #RUN which xelatex
 #RUN xelatex --version
#
#USER app
#WORKDIR /app 
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "HireMePls.dll"]