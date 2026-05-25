using System;
using System.Collections.Generic;

namespace CyberSecurityBot
{
    /// <summary>
    /// Contains all response logic. Extracted from ChatBot.cs so it can be
    /// shared between the console runner and the WinForms GUI.
    /// </summary>
    public class ResponseEngine
    {
        private static readonly Dictionary<string, string> _exact =
            new(StringComparer.OrdinalIgnoreCase)
        {
            ["how are you?"]        = "I'm just code, but I'm running perfectly!",
            ["how are you"]         = "I'm just code, but I'm running perfectly!",
            ["what's your purpose?"]= "I promote cybersecurity awareness and safe online practices.",
            ["what is your purpose"]= "I promote cybersecurity awareness and safe online practices.",
            ["what can i ask about?"]= "You can ask about passwords, phishing, malware, safe browsing, two-factor authentication, VPNs, and social engineering. Try typing any of those topics!",
            ["help"]                = "Topics I can help with:\n  • passwords\n  • phishing\n  • malware\n  • ransomware\n\nJust type a topic or ask a full question!",
        };

        private static readonly List<(string keyword, string response)> _keywords = new()
        {
            ("password",
             "Use long, unique passwords for every account — at least 12 characters mixing letters, numbers, and symbols. " +
             "A password manager (like Bitwarden or 1Password) can generate and store them securely so you never have to remember them all."),

            ("phishing",
             "Phishing attacks trick you into giving up credentials or installing malware via fake emails or websites. " +
             "Always verify the sender's address, hover over links before clicking, and never enter credentials on a page you reached via email. " +
             "When in doubt, go directly to the site by typing the URL yourself."),

            ("malware",
             "Malware is malicious software including viruses, trojans, spyware, and ransomware. " +
             "Keep your OS and apps updated, use reputable antivirus software, and avoid downloading files from untrusted sources."),

            ("ransomware",
             "Ransomware encrypts your files and demands payment for the key. " +
             "Regular offline backups are your best defence — if you have a clean backup, you can restore without paying. " +
             "Never open unexpected email attachments and keep software patched."),
        };
        

        public string GetResponse(string input)
        {
            // Exact match first
            if (_exact.TryGetValue(input.Trim(), out string? exact))
                return exact;

            // Keyword scan
            foreach (var (keyword, response) in _keywords)
            {
                if (input.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    return response;
            }

            return "I didn't quite understand that. Type \"help\" to see the topics I can assist with, or try rephrasing your question.";
        }
    }
}