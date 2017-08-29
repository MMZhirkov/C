//ChatServer
//Ver 1.0

////////////////////////////////
///// @author: Deuse     //////
///// @date: 28.08.16   //////
///// @prname: server  //////
////////////////////////////

#pragma comment(lib, "Ws2_32.lib")

#include <iostream>
#include "WinSock2.h"
#include "WS2tcpip.h"


SOCKET Connect;
SOCKET* Connections;
SOCKET Listen;

int ClientQuanity = 0;


void ToClient(int ID)
{
	char* Buffer = new char[1024];

	for (;;Sleep(75)) 
	{
		memset(Buffer, 0, sizeof(Buffer));

		if (recv(Connections[ID], Buffer, 1024, NULL)) 
		{
			printf(Buffer);
			printf("\n");

			for (int i = 0; i <= ClientQuanity; i++) 
			{
				send(Connections[i], Buffer, strlen(Buffer), NULL);
			}
		}
	}

	delete Buffer;
}

int main()
{
	setlocale(LC_ALL, "Russian");

	WSAData Date;
	WORD Version = MAKEWORD(2,2);

	int Result = WSAStartup(Version, &Date);

	if (Result != 0) 
	{
		return 0;
	}

	struct addrinfo hints;
	struct addrinfo * result;

	Connections = (SOCKET*)calloc(64, sizeof(SOCKET));

	ZeroMemory(&hints, sizeof(hints));

	hints.ai_family = AF_INET;
	hints.ai_flags = AI_PASSIVE;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;

	getaddrinfo(NULL, "7770", &hints, &result);

	Listen = socket(result->ai_family, result->ai_socktype, result->ai_protocol);

	bind(Listen, result->ai_addr, result->ai_addrlen);
	listen(Listen, SOMAXCONN);

	freeaddrinfo(result);

	printf("Server started...");
	char M_connect[] = "Connect...;;;5";
	int Len = strlen(M_connect);

	for (;;Sleep(75))
	{
		if (Connect = accept(Listen, NULL, NULL))
		{
			printf("Client connected...\n");
			Connections[ClientQuanity] = Connect;
			send(Connections[ClientQuanity], M_connect, Len, NULL);
			

			ClientQuanity++;
			CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)ToClient, (LPVOID)(ClientQuanity - 1), NULL, NULL);
		}
	}

	return 1;
}

