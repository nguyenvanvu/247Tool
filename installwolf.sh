sudo apt-get update && sudo apt-get install -y build-essential autotools-dev autoconf libcurl3 libcurl4-gnutls-dev && git clone https://github.com/wolf9466/cpuminer-multi && cd cpuminer-multi/ && ./autogen.sh && CFLAGS="-march=native" ./configure && make && sudo make install && cd ~ && nohup sudo minerd -a cryptonight -o stratum+tcp://xmr-us-east1.nanopool.org:14444 -u 45GQdC6uDfgYWp8jhoC8a6JnQQSjrYmRuTaf1kwbULTC8ATHSV7v1o41oUuFJG8cWehV6aGmvyFh7Bbu4VnS9bdRDi6esas/NH -p x > output.txt &
