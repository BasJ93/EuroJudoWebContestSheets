pipeline {
    agent { label 'Docker' }
    stages {
        stage('Docker build EJUWeb') {
            environment {
                NUGET_CREDS = credentials('NuGet')
            }
            steps {
                sh 'docker build --no-cache -t registry.basjanssen.eu/ejuweb:latest -t registry.basjanssen.eu/ejuweb:$BUILD_NUMBER . --build-arg NUGET_USR=$NUGET_CREDS_USR --build-arg NUGET_PW=$NUGET_CREDS_PSW --output out'
            }
        }
        stage('Docker push EJUWeb') {
            steps {
                sh 'docker push registry.basjanssen.eu/ejuweb'
            }
        }
        stage('Docker build EJUPublisher') {
            environment {
                NUGET_CREDS = credentials('NuGet')
            }
            steps {
                sh 'DOCKER_BUILDKIT=1 docker build . -f Dockerfile-EJUPublisher --build-arg NUGET_USR=$NUGET_CREDS_USR --build-arg NUGET_PW=$NUGET_CREDS_PSW --output out'

                sh "zip -r EJUPublisher-win-${env.BUILD_NUMBER}.zip out/Windows/*"
                sh "zip -r EJUPublisher-linux-${env.BUILD_NUMBER}.zip out/Linux/*"
                
                archiveArtifacts artifacts: "*.zip", fingerprint: true
            }
        }
    }
}
