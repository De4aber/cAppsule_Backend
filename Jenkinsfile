pipeline {
    agent any

    triggers {
        pollSCM "*/5 * * * *"
    }

    stages {
	
	    stage('Building: API') {
                when {
                    anyOf {
                        changeset "cAppsule"
                    }
                }
                    steps{
                        sh "echo '[API] Building...'"
                        sh "dotnet build cAppsule"
                    }
                    post {
                    		success {
                    		sh "echo 'API built successfully'"
                    		}
                    	}
                }
    }
}
