using System.Linq;
using NBitcoin.Secp256k1;
using KeyJoin.Crypto;
using KeyJoin.Crypto.Randomness;
using KeyJoin.Crypto.ZeroKnowledge;
using KeyJoin.Crypto.ZeroKnowledge.LinearRelation;

namespace KeyJoin.Tests.Crypto;

internal class ProofSystemHelpers
{
	public static bool Verify(Statement statement, Proof proof)
	{
		return ProofSystem.Verify(new Transcript(Array.Empty<byte>()), new[] { statement }, new[] { proof });
	}

	public static Proof Prove(Knowledge knowledge, BitmaseRandom random)
	{
		return ProofSystem.Prove(new Transcript(Array.Empty<byte>()), new[] { knowledge }, random).First();
	}

	public static Proof Prove(Statement statement, Scalar witness, BitmaseRandom random)
	{
		return Prove(statement, new ScalarVector(witness), random);
	}

	public static Proof Prove(Statement statement, ScalarVector witness, BitmaseRandom random)
	{
		return Prove(new Knowledge(statement, witness), random);
	}
}
