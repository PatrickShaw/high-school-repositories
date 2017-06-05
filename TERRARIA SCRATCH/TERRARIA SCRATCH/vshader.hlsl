struct VOut
{
	float4 position : SV_POSITION;
	float4 colour : COLOR;
};

VOut VShader(float4 position : POSITION, float4 colour : COLOR)
{
	VOut output;

	output.position = position;
	output.colour = colour;

	return output;
}


