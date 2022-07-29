using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int secondsLeft;
    public Transform ballPosition;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text timerText;

    private PaddleUnit player1Paddle;
    private PaddleUnit player2Paddle;
    private Ball ball;

    // allows the player manager to add the scripts when players join
    public void TrackPlayer1(PaddleUnit paddle){
        player1Paddle = paddle;
    }
    public void TrackPlayer2(PaddleUnit paddle){
        player2Paddle = paddle;
        // spawns ball only when players have joined
        SpawnBall();
    }
    void SpawnBall(){
        ball = Instantiate(ball, ballPosition.position, Quaternion.identity);
    }

    public void Player1Scores()
    {
        player1Paddle.AddToScore();

        this.player1ScoreText.text = player1Paddle.score.ToString();
        ResetRound();
    }

    public void Player2Scores()
    {
        player2Paddle.AddToScore();
        
        this.player2ScoreText.text = player2Paddle.score.ToString();
        ResetRound();
    }

    // FIXME: add code to deal with broken ball

    // FIXME: add timer

    /*
        This should change the scene to the "GameOver" scene and display who won.
    */
    public void EndGame(){
         /*
            FIXME: 
                [ ] This should change the scene to the "GameOver" scene and display who won.
                [ ] There should be options to restart or return to start screen.
                [ ] Player input maps should be changed to UI for this.
        */
        if (player1Paddle.score > player2Paddle.score){
            timerText.text = "P1 Wins";
        }else if (player2Paddle.score > player1Paddle.score){
            timerText.text = "P2 Wins";
        }else{
            timerText.text = "Tie";
        }
    }

    private void ResetRound()
    {
        this.player1Paddle.ResetPosition();
        this.player2Paddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }
}
