echo $DOCKERHUB_PASSWORD | docker login -u $DOCKERHUB_USERNAME --password-stdin
docker push sergeyshaykhullin/documentio:1.0.$TRAVIS_BUILD_NUMBER