using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;

namespace NovelRepositories.Utils;

public static class IpUtils
{
    /// <summary>
    /// 将控制器传进来的ipv4地址转换为整数
    /// ipv4地址有4*8位, 刚好可以满足无符号整数uint的大小.
    /// 通过移位和并运算得出ipv4的存储值
    /// </summary>
    /// <param name="ipv4">传入ipv4的地址</param>
    /// <returns>返回对应的整数</returns>
    public static uint Ip2Int(string ipv4)
    {
        
        var segments = ipv4.Split('.');
        uint ip = 0;
        if (segments.Length != 4)
        {
            throw new Exception("Invalid Ipv4 Address!");
        }
        for (var i = 0; i < 4; i++)
        {
            ip |= uint.Parse(segments[i]) << (8 * (3-i));
        }
        return ip;
    }

    /// <summary>
    ///  将数据库中的ip转化为字符串类型的ip地址
    /// </summary>
    /// <param name="ipv4Int"></param>
    /// <returns>字符串ipv4地址</returns>
    public static string Int2Ip(uint ipv4Int)
    => new StringBuilder().Append((ipv4Int >> 24)).Append('.')
            .Append((ipv4Int >> 16) & 0xFF).Append('.')
            .Append((ipv4Int >> 8) & 0xFF).Append('.')
            .Append(ipv4Int & 0xFF).ToString();
}