import 'semantic-ui-css/semantic.min.css'
import React from 'react'
import ReactDOM from 'react-dom'

import ApolloClient from 'apollo-boost';
import { ApolloProvider } from '@apollo/react-hooks';

import { Router } from './router'
import { BrowserRouter } from 'react-router-dom'

const graphql = new ApolloClient({
	uri: 'https://localhost:5001/graphql'
})

ReactDOM.render(
	<ApolloProvider client={ graphql }>
		<BrowserRouter>
			<Router/>
		</BrowserRouter>
	</ApolloProvider>,
	document.getElementById('root')
)