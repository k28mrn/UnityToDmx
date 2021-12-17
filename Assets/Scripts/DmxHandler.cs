using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public class DmxHandler {
	string address;
	int port;
	int universe;
	public byte[] data = new byte[512];
	private byte[] oldData = new byte[512];
	private UdpClient udpClient = new UdpClient();

	public DmxHandler(string address, int port, int universe) {
		this.address = address;
		this.port = port;
		this.universe = universe;
	}

	/// <summary>
	/// 更新: 前回更新と違いがあるときのみ
	/// </summary>
	internal void Update () {
		if (!data.SequenceEqual(oldData)) {
			ArtNetSend();
			Buffer.BlockCopy(data, 0, oldData, 0, 512);
		}
	}

	/// <summary>
	/// DMXデータ送信
	/// </summary>
	void ArtNetSend () {
		byte[] dgram = new byte[512 + 18];
		dgram[0] = (byte)'A';
		dgram[1] = (byte)'r';
		dgram[2] = (byte)'t';
		dgram[3] = (byte)'-';
		dgram[4] = (byte)'N';
		dgram[5] = (byte)'e';
		dgram[6] = (byte)'t';
		dgram[7] = 0;
		dgram[8] = 0;
		dgram[9] = 0x50;
		dgram[10] = 0;
		dgram[11] = 14;
		dgram[12] = 0;
		dgram[13] = 0;
		dgram[14] = (byte)(universe & 0xff);
		dgram[15] = (byte)((universe >> 8) & 0x7f);
		dgram[16] = 2;
		dgram[17] = 0;
		
		Buffer.BlockCopy(data, 0, dgram, 18, 512);
		
		udpClient.Send(dgram, dgram.Length, address, port);
	}
}