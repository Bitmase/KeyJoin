using System.Runtime.Serialization;

namespace KeyJoin.Crypto;

[Serializable]
public class KeyJoinCryptoException : Exception
{
	public KeyJoinCryptoException(KeyJoinCryptoErrorCode errorCode, string? message = null, Exception? innerException = null)
		: base(message, innerException)
	{
		ErrorCode = errorCode;
	}

	protected KeyJoinCryptoException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public KeyJoinCryptoErrorCode ErrorCode { get; }
}
