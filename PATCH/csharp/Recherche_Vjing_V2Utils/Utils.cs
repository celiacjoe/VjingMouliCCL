// For examples, see:
// https://thegraybook.vvvv.org/reference/extending/writing-nodes.html#examples

namespace Main;

public static class f
{
    public static float fract(float t) => t - (float)Math.Floor(t);
    public static float floor(float t) => (float)Math.Floor(t);
    public static float sin(float t) => (float)Math.Sin(t);
    public static float GetTime() => (float)DateTime.Now.TimeOfDay.TotalSeconds;
    public static float step(float edge, float x) => x < edge ? 0f : 1f;

    // Custom mod function (remainder after division)
    public static float mod(float a, float b) => a - b * (float)Math.Floor(a / b);

    // Moved clamp function inside the f class
    public static float clamp(float value, float min, float max) => Math.Max(min, Math.Min(max, value));
    public static float rd(float t) => (float)f.fract(f.sin(f.floor(t) * 42) * 4857.26f);
    public static float lerp(float a, float b, float t) => a + t * (b - a);

    public static float smoothstep(float edge0, float edge1, float x)
    {
        float t = clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
        return t * t * (3.0f - 2.0f * t);
    }
}

public static class elements
{
    public static int rswi(float t, float shi, float fa) =>
        (int)f.step(fa, f.fract(f.sin(f.floor(t + shi) * 42) * 4857.26f));
    public static float nora(float t, float shi)
    {
        return (float)f.lerp(f.rd(t + shi), f.rd(t + 1 + shi), f.smoothstep(0, 1, f.fract(t)));
    }
    public static float it(float t, float shi)
    {
        float r = 0.0f; float a = 0.5f;
        for (int i = 0; i < 3; i++) { r += elements.nora(t / a, shi / a) * a; a *= 0.5f; }
        return r;
    }
    public static int euswi(float a, float b, float t)
    {
        float t1 = f.GetTime() * t;
        float tt = f.mod(f.floor(t1) * a, b);
        return (int)f.step(0.5f, f.floor((tt - a) / a) + 1 + f.fract(t1));
    }


}

public static class Utils
{
    public static float DemoNode(float a, float b)
    {
        return a + b;
    }

    public static float Fract(float t)
    {
        return t - (float)Math.Floor(t);
    }

    public static float Floor(float t)
    {
        return (float)Math.Floor(t);
    }
    public static float Sin(float t)
    {
        return (float)Math.Sin(t);
    }
    public static float GetTime(float t)
    {
        return (float)DateTime.Now.TimeOfDay.TotalSeconds;
    }
    public static float Step(float edge, float x)
    {
        return x < edge ? 0f : 1f;
    }

    // Custom mod function (remainder after division)
    public static float Mod(float a, float b)
    {
        return a - b * (float)Math.Floor(a / b);
    }