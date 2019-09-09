import html from 'rollup-plugin-bundle-html';
import del from 'rollup-plugin-delete'
import typescript from 'rollup-plugin-typescript2';
import nodeResolve from 'rollup-plugin-node-resolve';
import commonjs from 'rollup-plugin-commonjs';
import replace from 'rollup-plugin-replace';
import serve from 'rollup-plugin-serve';
import livereload from 'rollup-plugin-livereload';
import {uglify} from 'rollup-plugin-uglify';

const dev = 'development';
const prod = 'production';

const nodeEnv = parseNodeEnv(process.env.NODE_ENV);

const plugins = [
    del({targets: 'build/*'}),
    replace({
        'process.env.NODE_ENV': JSON.stringify(nodeEnv),
    }),
    html({
        template: 'public/index.html',
        dest: 'build',
        filename: 'index.html',
        inject: 'body'
    }),
    nodeResolve(),
    commonjs({
        include: 'node_modules/**',
        namedExports: {
            'node_modules/react-dom/index.js': [
                'render',
            ],
            'node_modules/react/index.js': [
                'Component',
                'PureComponent',
                'PropTypes',
                'createElement',
            ],
        },
    }),
    typescript()
];

if (nodeEnv === dev) {
    plugins.push(serve({
        open: true,
        port: 3000,
        historyApiFallback: true,
        contentBase: 'build'
    }));
    plugins.push(livereload());
}

if (nodeEnv === prod) {
    plugins.push(uglify());
}

export default {
    input: 'src/index.tsx',
    output: {
        file: 'build/bundle.js',
        format: 'iife'
    },
    plugins
};

function parseNodeEnv(nodeEnv) {
    if (nodeEnv === prod || nodeEnv === dev) {
        return nodeEnv;
    }
    return dev;
}