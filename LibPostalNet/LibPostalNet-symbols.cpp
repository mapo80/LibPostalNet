#include <libpostal.h>

extern "C" { void LibPostalNet_symbols1(void* instance) { new (instance) libpostal_normalize_options(); } }
extern "C" { void LibPostalNet_symbols2(void* instance, const libpostal_normalize_options& _0) { new (instance) libpostal_normalize_options(_0); } }
libpostal_normalize_options& (libpostal_normalize_options::*LibPostalNet_symbols3)(const libpostal_normalize_options&) = &libpostal_normalize_options::operator=;
libpostal_normalize_options& (libpostal_normalize_options::*LibPostalNet_symbols4)(libpostal_normalize_options&&) = &libpostal_normalize_options::operator=;
extern "C" { void LibPostalNet_symbols5(libpostal_normalize_options* instance) { instance->~libpostal_normalize_options(); } }
extern "C" { void LibPostalNet_symbols6(void* instance) { new (instance) libpostal_address_parser_response(); } }
extern "C" { void LibPostalNet_symbols7(void* instance, const libpostal_address_parser_response& _0) { new (instance) libpostal_address_parser_response(_0); } }
libpostal_address_parser_response& (libpostal_address_parser_response::*LibPostalNet_symbols8)(const libpostal_address_parser_response&) = &libpostal_address_parser_response::operator=;
libpostal_address_parser_response& (libpostal_address_parser_response::*LibPostalNet_symbols9)(libpostal_address_parser_response&&) = &libpostal_address_parser_response::operator=;
extern "C" { void LibPostalNet_symbols10(libpostal_address_parser_response* instance) { instance->~libpostal_address_parser_response(); } }
extern "C" { void LibPostalNet_symbols11(void* instance) { new (instance) libpostal_address_parser_options(); } }
extern "C" { void LibPostalNet_symbols12(void* instance, const libpostal_address_parser_options& _0) { new (instance) libpostal_address_parser_options(_0); } }
libpostal_address_parser_options& (libpostal_address_parser_options::*LibPostalNet_symbols13)(const libpostal_address_parser_options&) = &libpostal_address_parser_options::operator=;
libpostal_address_parser_options& (libpostal_address_parser_options::*LibPostalNet_symbols14)(libpostal_address_parser_options&&) = &libpostal_address_parser_options::operator=;
extern "C" { void LibPostalNet_symbols15(libpostal_address_parser_options* instance) { instance->~libpostal_address_parser_options(); } }
