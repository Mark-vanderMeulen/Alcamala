using Elysium.Icons;

namespace Alcamala.Models;

public static class AlcamalaLogo
{
    public static Icon Icon = new()
    {
        Name = "Logo",
        Paths = [
            "<defs><mask id=\"dropletCut\"><rect width=\"256\" height=\"256\"/><path fill=\"black\" d=\"M128 88 C148 111 158 124 158 142 C158 160 145 174 128 174 C111 174 98 160 98 142 C98 124 108 111 128 88 Z\"/></mask></defs>",
            "<path mask=\"url(#dropletCut)\" d=\"M128 24 C108 24 91 36 78 62 L34 190 C27 210 40 228 61 228 C75 228 85 221 92 204 L128 112 L164 204 C171 221 181 228 195 228 C216 228 229 210 222 190 L178 62 C165 36 148 24 128 24 Z\"/>"
            //"<defs><mask id=\"dropletCut\"><rect width=\"256\" height=\"256\" fill=\"white\"/><path fill=\"red\" d=\"M128 88 C148 111 158 124 158 142 C158 160 145 174 128 174 C111 174 98 160 98 142 C98 124 108 111 128 88 Z\"/></mask></defs>",
            //"<path fill=\"currentColor\" mask=\"url(#dropletCut)\" d=\"M128 24 C108 24 91 36 78 62 L34 190 C27 210 40 228 61 228 C75 228 85 221 92 204 L128 112 L164 204 C171 221 181 228 195 228 C216 228 229 210 222 190 L178 62 C165 36 148 24 128 24 Z\"/>"
        ],
        ViewBoxWidth = 256,
        ViewBoxHeight = 256
    };
}
