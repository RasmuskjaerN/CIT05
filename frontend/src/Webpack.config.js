module.exports = {
    // Other webpack options...
    resolve: {
      fallback: {
        zlib: require.resolve('browserify-zlib'),
        querystring: require.resolve('querystring-es3'),
        path: require.resolve('path-browserify'),
        crypto: require.resolve('crypto-browserify'),
        fs: require.resolve('fs-extra'),
      },
    },
  };