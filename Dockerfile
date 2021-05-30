FROM mcr.microsoft.com/dotnet/sdk:5.0

COPY . /app
WORKDIR /app

RUN git clone -b main --no-checkout https://github.com/LuzFaltex/luzfaltex.com.git /app/source/
RUN mv /app/source/.git /app
RUN rmdir /app/source/
RUN git reset --hard HEAD

RUN ["dotnet", "build"]

EXPOSE 5000/tcp
ENTRYPOINT [ "dotnet", "run", "--", "deploy" ]