#version 330

void main()
{
	float localOffset = mod(gl_FragCoord.x + gl_FragCoord.y, 10.0);

	vec4 finalColor =
		localOffset < 5.0 ?
			vec4(0.6, 0.6, 0.6, 1.0) :
			vec4(0.4, 0.4, 0.4, 1.0);

	gl_FragColor = finalColor;
}