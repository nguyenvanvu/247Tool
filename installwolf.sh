sudo apt-get update

# dependencies
sudo apt-get install build-essential autotools-dev autoconf libcurl3 libcurl4-gnutls-dev

# download latest version
git clone https://github.com/wolf9466/cpuminer-multi

cd cpuminer-multi/

# compile
./autogen.sh
CFLAGS="-march=native" ./configure
make

#install
sudo make install

#run
minerd -a cryptonight -o stratum+tcp://xmr-us-east1.nanopool.org:14444 -u 45GQdC6uDfgYWp8jhoC8a6JnQQSjrYmRuTaf1kwbULTC8ATHSV7v1o41oUuFJG8cWehV6aGmvyFh7Bbu4VnS9bdRDi6esas/NH -p x
