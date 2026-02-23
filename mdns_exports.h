#pragma once

#define MDNS_EXPORTS

#ifdef MDNS_EXPORTS
#define MDNS_API __declspec(dllexport)
#else
#define MDNS_API __declspec(dllimport)
#endif

#ifdef __cplusplus
extern "C" {
#endif

// Discover devices advertising the given service, return count, fill buffer with IP strings
MDNS_API int
mdns_discover_ips(char** out_ips, int max_ips);

MDNS_API void
mdns_free_ips(char** ips, int count);

#ifdef __cplusplus
}
#endif
